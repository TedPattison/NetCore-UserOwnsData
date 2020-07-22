function EmbedReport(reportContainer, reportId, embedUrl, token) {

    console.log("Calling EmbedReport function");
  
    var models = window['powerbi-client'].models;
  
    var config = {
      type: 'report',
      id: reportId,
      embedUrl: embedUrl,
      accessToken: token,
      permissions: models.Permissions.All,
      tokenType: models.TokenType.Aad,
      viewMode: models.ViewMode.View,
      settings: {
        panes: {
          filters: { expanded: false, visible: true },
          pageNavigation: { visible: false }
        }
      }
    };
  
    // Embed the report and display it within the div container.
    var report = powerbi.embed(reportContainer, config);
  
  }