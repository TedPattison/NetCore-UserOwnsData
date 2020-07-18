using System;
using System.Threading.Tasks;
using Microsoft.Identity.Web;
using Microsoft.Rest;
using Microsoft.PowerBI.Api;

namespace UserOwnsData.Services {

  public class EmbeddedReportViewModel {
    public string Id;
    public string Name;
    public string EmbedUrl;
    public string Token;
  }

  public class PowerBiServiceApi {

    readonly ITokenAcquisition tokenAcquisition;

    public PowerBiServiceApi(ITokenAcquisition tokenAcquisition) {
      this.tokenAcquisition = tokenAcquisition;
    }

    const string urlPowerBiServiceApiRoot = "https://api.powerbi.com/";

    public static readonly string[] RequiredScopes =
      new string[] {
        "https://analysis.windows.net/powerbi/api/Group.Read.All",
        "https://analysis.windows.net/powerbi/api/Dashboard.Read.All",
        "https://analysis.windows.net/powerbi/api/Report.ReadWrite.All",
        "https://analysis.windows.net/powerbi/api/Dataset.ReadWrite.All",
        "https://analysis.windows.net/powerbi/api/Content.Create",
    };

    public async Task<EmbeddedReportViewModel> GetReport(Guid WorkspaceId, Guid ReportId) {
      // get access token
      var accessToken = this.tokenAcquisition.GetAccessTokenForUserAsync(RequiredScopes).Result;
      // create PBI client to call Power BI Service API
      var tokenCredentials = new TokenCredentials(accessToken, "Bearer");
      PowerBIClient pbiClient = new PowerBIClient(new Uri(urlPowerBiServiceApiRoot), tokenCredentials);
      // call to Power BI Service API to get embedding data
      var report = await pbiClient.Reports.GetReportInGroupAsync(WorkspaceId, ReportId);
      // return report embedding data to caller
      return new EmbeddedReportViewModel {
        Id = report.Id.ToString(),
        EmbedUrl = report.EmbedUrl,
        Name = report.Name,
        Token = accessToken
      };
    }
  
  }
}
