using System;
using System.Web.UI;
using DevExpress.Web.ASPxGridView;

public partial class _Default : Page {
    protected void Page_Load(object sender, EventArgs e) {
        ColumnVisibilityManager columnVisibilityManager = new ColumnVisibilityManager(gvGrid);
        Form.Controls.AddAt(0, columnVisibilityManager);
    }
    protected void OnCustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        if(e.Parameters.IndexOf(ColumnVisibilityManager.CvmCallbackPrefix) == 0)
            ColumnVisibilityManager.ProcessCallback(sender as ASPxGridView, e.Parameters);
        else
            throw new InvalidOperationException("Invalid callback parameters.");
    }
}
