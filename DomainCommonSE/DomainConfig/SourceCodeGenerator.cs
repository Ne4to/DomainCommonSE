using System;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Linq;
using DomainCommonSE.Domain;
using System.Collections.Generic;

namespace DomainCommonSE.DomainConfig
{
	public class SourceCodeGenerator
	{
		private const string ObjectCodeConstFieldName = "ObjectCode";

		public const string PropertyRegionName = "Свойства";
		public const string LinkRegionName = "Ссылки";
		public const string ConstructorRegionName = "Конструктор";

		private const string PropertiesField = "Properties";
		private const string PropertyValueField = "Value";

		private const string LinksField = "Links";
		private const string LinkReturnType = "DomainObjectCollection";
		private const string LinkObjectField = "Objects";

		private static CodeCommentStatement GetSummaryComment(string comment)
		{
			return new CodeCommentStatement(String.Format("<summary>\r\n {0}\r\n</summary>", comment), true);
		}

		private static void DomainPropertyCode(DomainPropertyConfig propConfig, out CodeMemberField propertyCodeConst, out CodeMemberProperty prop)
		{
			string propConstName = String.Format("Prop{0}", propConfig.CodeName);
			propertyCodeConst = new CodeMemberField
			{
				Attributes = MemberAttributes.Public | MemberAttributes.Const,
				Name = propConstName,
				Type = new CodeTypeReference(typeof(String)),
				InitExpression = new CodePrimitiveExpression(propConfig.Code)
			};

			SetSummaryComment(propertyCodeConst, String.Format("Код свойства '{0}'", propConfig.Description));

			prop = new CodeMemberProperty()
			{
				Name = propConfig.CodeName,
				Attributes = MemberAttributes.Public | MemberAttributes.Final,
				Type = new CodeTypeReference(propConfig.DataType)
			};

			CodeArrayIndexerExpression propIndexer = new CodeArrayIndexerExpression(
							new CodeVariableReferenceExpression(PropertiesField),
							new CodeVariableReferenceExpression(propConstName));



			prop.GetStatements.Add(new CodeMethodReturnStatement(new CodeCastExpression(propConfig.DataType, new CodeFieldReferenceExpression(propIndexer, PropertyValueField))));

			prop.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(propIndexer, PropertyValueField), new CodePropertySetValueReferenceExpression()));
			SetSummaryComment(prop, propConfig.Description);
		}

		private static void DomainObjectPropertiesCode(DomainObjectConfig obj, CodeTypeDeclaration targetClass)
		{
			bool isFirstProperty = true;
			CodeMemberProperty lastProperty = null;
			foreach (DomainPropertyConfig propConfig in obj.Property)
			{
				CodeMemberField propertyCodeConst = null;
				CodeMemberProperty prop = null;
				DomainPropertyCode(propConfig, out propertyCodeConst, out prop);

				targetClass.Members.Add(propertyCodeConst);

				// начало региона свойств
				if (isFirstProperty)
				{
					CodeRegionDirective startPropertiesRegion = new CodeRegionDirective(CodeRegionMode.Start, PropertyRegionName);
					propertyCodeConst.StartDirectives.Add(startPropertiesRegion);
					isFirstProperty = false;
				}

				targetClass.Members.Add(prop);
				lastProperty = prop;
			}

			// закрываем регион свойств
			if (lastProperty != null)
			{
				CodeRegionDirective endPropertiesRegion = new CodeRegionDirective(CodeRegionMode.End, string.Empty);
				lastProperty.EndDirectives.Add(endPropertiesRegion);
			}
		}

		private static CodeMemberField DomainLinkCodeConstCode(DomainLinkConfig linkConfig)
		{
			string linkConstName = String.Format("Link{0}", linkConfig.Code);
			CodeMemberField linkCodeConst = new CodeMemberField
			{
				Attributes = MemberAttributes.Family | MemberAttributes.Const,
				Name = linkConstName,
				Type = new CodeTypeReference(typeof(String)),
				InitExpression = new CodePrimitiveExpression(linkConfig.Code)
			};

			SetSummaryComment(linkCodeConst, String.Format("Код ссылки '{0}'", linkConfig.Code));

			return linkCodeConst;
		}

		private static void SetSummaryComment(CodeTypeMember codeMember, string comment)
		{
			if (!String.IsNullOrWhiteSpace(comment))
			{
				CodeCommentStatement commentStatement = GetSummaryComment(comment);
				codeMember.Comments.Add(commentStatement);
			}
		}

		private static CodeMemberField LeftLinkPrivateCollection(DomainLinkConfig linkConfig)
		{
			return new CodeMemberField(typeof(DomainObjectCollection), String.Format("m_{0}{1}", linkConfig.LeftCollectionName.ToLower()[0], linkConfig.LeftCollectionName.Substring(1)));
		}

		private static CodeMemberProperty LeftLinkCollection(DomainLinkConfig linkConfig, CodeMemberField privateCollection)
		{
			CodeMemberProperty link = new CodeMemberProperty()
			{
				Name = linkConfig.LeftCollectionName,
				Attributes = MemberAttributes.Public | MemberAttributes.Final,
				Type = new CodeTypeReference(typeof(DomainObjectCollection)),
			};

			link.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), privateCollection.Name)));

			SetSummaryComment(link, linkConfig.LeftToRightDescription);

			return link;
		}

		private static CodeMemberProperty RightLinkCollection(DomainLinkConfig linkConfig)
		{
			throw new NotImplementedException();
		}

		private static void DomainObjectLinksCode(DomainObjectInquiry inquiry, DomainObjectConfig obj, CodeTypeDeclaration targetClass, CodeConstructor constructor, CodeConstructor newObjectConstructor)
		{
			foreach (DomainLinkConfig link in inquiry.ALinks)
			{
				if (link.LeftObject != obj && link.RightObject != obj)
					continue;

				CodeMemberField linkCodeConst = DomainLinkCodeConstCode(link);
				targetClass.Members.Add(linkCodeConst);

				if (link.LeftObject == obj)
				{
					CodeMemberField leftPrivateColl = LeftLinkPrivateCollection(link);
					targetClass.Members.Add(leftPrivateColl);

					CodeMemberProperty leftPropField = LeftLinkCollection(link, leftPrivateColl);
					targetClass.Members.Add(leftPropField);

					CodeMethodInvokeExpression linkFunc = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "GetLinkCollection"), new CodeVariableReferenceExpression(linkCodeConst.Name), new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("eLinkSide"), eLinkSide.Left.ToString()));
					CodeAssignStatement initCollectionStatement = new CodeAssignStatement(new CodeVariableReferenceExpression(leftPrivateColl.Name), linkFunc);

					constructor.Statements.Add(initCollectionStatement);
					newObjectConstructor.Statements.Add(initCollectionStatement);
				}

				if (link.RightObject == obj)
				{
					//CodeMemberProperty rightPropField = RightLinkCollection(link);				
					//targetClass.Members.Add(rightPropField);
				}
			}

			//	throw new NotImplementedException();

			//bool isFirstLink = true;
			//CodeMemberProperty lastLink = null;
			//foreach (EntityLinkConfig linkConfig in obj.Link)
			//{
			//    CodeMemberField linkCodeConst = null;
			//    CodeMemberProperty link = null;
			//    EntityLinkCode(linkConfig, out linkCodeConst, out link);

			//    targetClass.Members.Add(linkCodeConst);

			//    // начало региона свойств
			//    if (isFirstLink)
			//    {
			//        CodeRegionDirective startLinksRegion = new CodeRegionDirective(CodeRegionMode.Start, LinkRegionName);
			//        linkCodeConst.StartDirectives.Add(startLinksRegion);
			//        isFirstLink = false;
			//    }

			//    targetClass.Members.Add(link);
			//    lastLink = link;
			//}

			//// закрываем регион свойств
			//if (lastLink != null)
			//{
			//    CodeRegionDirective endLinksRegion = new CodeRegionDirective(CodeRegionMode.End, string.Empty);
			//    lastLink.EndDirectives.Add(endLinksRegion);
			//}
		}

		public static string DomainObjectCode(DomainObjectInquiry inquiry, DomainObjectConfig obj)
		{
			CodeCompileUnit unit = new CodeCompileUnit();
			CodeNamespace targetNamespace = new CodeNamespace("NamespaceName");
			unit.Namespaces.Add(targetNamespace);

			targetNamespace.Imports.Add(new CodeNamespaceImport("System"));
			targetNamespace.Imports.Add(new CodeNamespaceImport("DomainCommonSE"));
			targetNamespace.Imports.Add(new CodeNamespaceImport("DomainCommonSE.Domain"));
			targetNamespace.Imports.Add(new CodeNamespaceImport("DomainCommonSE.DomainConfig"));

			// объявление класса
			CodeTypeDeclaration targetClass = new CodeTypeDeclaration(obj.CodeName)
			{
				IsClass = true,
				TypeAttributes = TypeAttributes.Public
			};
			targetNamespace.Types.Add(targetClass);

			// базовый класс
			targetClass.BaseTypes.Add(typeof(DomainObject));

			// комментарий - описание класса
			SetSummaryComment(targetClass, obj.Description);

			// строковая константа - код класса
			CodeMemberField objectNameConst = new CodeMemberField
			{
				Attributes = MemberAttributes.Public | MemberAttributes.Const,
				Name = ObjectCodeConstFieldName,
				Type = new CodeTypeReference(typeof(String)),
				InitExpression = new CodePrimitiveExpression(obj.Code)
			};

			targetClass.Members.Add(objectNameConst);

			#region Конструктор загрузки объекта из БД
			CodeConstructor loadObjectConstructor = new CodeConstructor();
			loadObjectConstructor.Attributes = MemberAttributes.Public;

			loadObjectConstructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(SessionIdentifier), "sessionId"));
			loadObjectConstructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression("sessionId"));

			loadObjectConstructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(ObjectIdentifier), "objectId"));
			loadObjectConstructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression("objectId"));

			targetClass.Members.Add(loadObjectConstructor);
			#endregion

			#region Конструктор создания нового объекта
			CodeConstructor newObjectConstructor = new CodeConstructor();
			newObjectConstructor.Attributes = MemberAttributes.Public;

			newObjectConstructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(SessionIdentifier), "sessionId"));
			newObjectConstructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression("sessionId"));
			newObjectConstructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression(ObjectCodeConstFieldName));

			targetClass.Members.Add(newObjectConstructor);
			#endregion

			DomainObjectPropertiesCode(obj, targetClass);
			DomainObjectLinksCode(inquiry, obj, targetClass, loadObjectConstructor, newObjectConstructor);

			StringBuilder resultCode = new StringBuilder();
			using (StringWriter sourceWriter = new StringWriter(resultCode))
			{
				CreateProvider().GenerateCodeFromCompileUnit(unit, sourceWriter, CreateGeneratorOptions());
			}

			return resultCode.ToString();
		}

		private static CodeDomProvider CreateProvider()
		{
			return CodeDomProvider.CreateProvider("CSharp");
		}

		private static CodeGeneratorOptions CreateGeneratorOptions()
		{
			return new CodeGeneratorOptions
			{
				BracingStyle = "C",
				IndentString = "\t",
				BlankLinesBetweenMembers = true,
				VerbatimOrder = true // если сортировать по порядку
			};
		}

		public static string DomainPropertyCode(DomainPropertyConfig propConfig)
		{
			CodeMemberField propertyCodeConst = null;
			CodeMemberProperty prop = null;
			DomainPropertyCode(propConfig, out propertyCodeConst, out prop);

			CodeDomProvider provider = CreateProvider();
			CodeGeneratorOptions createGeneratorOptions = CreateGeneratorOptions();

			StringBuilder resultCode = new StringBuilder();
			using (StringWriter sourceWriter = new StringWriter(resultCode))
			{
				provider.GenerateCodeFromMember(propertyCodeConst, sourceWriter, createGeneratorOptions);
				provider.GenerateCodeFromMember(prop, sourceWriter, createGeneratorOptions);
			}

			return resultCode.ToString();
		}

		public static string DomainObjectPropertiesCode(DomainObjectConfig objConfig)
		{
			StringBuilder resultCode = new StringBuilder();
			using (StringWriter sourceWriter = new StringWriter(resultCode))
			{
				CodeDomProvider provider = CreateProvider();
				CodeGeneratorOptions createGeneratorOptions = CreateGeneratorOptions();

				foreach (DomainPropertyConfig propConfig in objConfig.Property)
				{
					CodeMemberField propertyCodeConst = null;
					CodeMemberProperty prop = null;
					DomainPropertyCode(propConfig, out propertyCodeConst, out prop);

					provider.GenerateCodeFromMember(propertyCodeConst, sourceWriter, createGeneratorOptions);
					provider.GenerateCodeFromMember(prop, sourceWriter, createGeneratorOptions);
				}
			}

			return resultCode.ToString();
		}

		public static string DomainLinkCode(DomainLinkConfig linkConfig)
		{
			throw new NotImplementedException();

			//CodeMemberField linkCodeConst = null;
			//CodeMemberProperty link = null;
			//EntityLinkCode(linkConfig, out linkCodeConst, out link);

			//CodeDomProvider provider = CreateProvider();
			//CodeGeneratorOptions createGeneratorOptions = CreateGeneratorOptions();

			//StringBuilder resultCode = new StringBuilder();
			//using (StringWriter sourceWriter = new StringWriter(resultCode))
			//{
			//    provider.GenerateCodeFromMember(linkCodeConst, sourceWriter, createGeneratorOptions);
			//    provider.GenerateCodeFromMember(link, sourceWriter, createGeneratorOptions);
			//}

			//return resultCode.ToString();
		}

		public static string DomainObjectLinksCode(DomainObjectConfig objConfig)
		{
			throw new NotImplementedException();

			//StringBuilder resultCode = new StringBuilder();
			//using (StringWriter sourceWriter = new StringWriter(resultCode))
			//{
			//    CodeDomProvider provider = CreateProvider();
			//    CodeGeneratorOptions createGeneratorOptions = CreateGeneratorOptions();

			//    foreach (EntityLinkConfig linkConfig in objConfig.Link)
			//    {
			//        CodeMemberField linkCodeConst = null;
			//        CodeMemberProperty link = null;
			//        EntityLinkCode(linkConfig, out linkCodeConst, out link);

			//        provider.GenerateCodeFromMember(linkCodeConst, sourceWriter, createGeneratorOptions);
			//        provider.GenerateCodeFromMember(link, sourceWriter, createGeneratorOptions);
			//    }
			//}

			//return resultCode.ToString();
		}
	}
}
