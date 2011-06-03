using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class InquiryDbProviderControl : DomainCommonSE.ConfigLibrary.InquiryProviderControl
	{
		public InquiryDbProviderControl()
		{
			InitializeComponent();
		}

		public override ObjectInquiryProvider GetInquiryProvider()
		{
			IDbCommonConnection connection = dbConnectControl.GetConnection();
			return new InquiryDbProvider(connection);
		}
	}
}
