using System;
using System.Web.UI.WebControls;
using DevExpress.Web;

public class ColumnVisibilityManager : WebControl {
    public const string CvmCallbackPrefix = "cvm!";
    private ASPxGridView gridView;

    public ColumnVisibilityManager(ASPxGridView gridView) {
        this.gridView = gridView;
	}

    private ASPxGridView GridView {
        get { return gridView; }
    }

    public static void ProcessCallback(ASPxGridView gridView, string callbackParam) {
        callbackParam = callbackParam.Substring(CvmCallbackPrefix.Length);
        int indexOfSeparator = callbackParam.IndexOf('|');
        bool isColumnVisible = byte.Parse(callbackParam.Substring(0, indexOfSeparator)) > 0;
        string columnName = callbackParam.Substring(indexOfSeparator + 1);
        gridView.Columns[columnName].Visible = isColumnVisible;
    }

    protected override void CreateChildControls() {
        Table table = new Table();
        Controls.Add(table);
        foreach(GridViewColumn column in GridView.Columns) {
            TableRow row = new TableRow();
            table.Rows.Add(row);
            TableCell cell = new TableCell();
            row.Cells.Add(cell);
            CreateColumnVisibilitySwitch(cell, column);
        }
    }
    private void CreateColumnVisibilitySwitch(WebControl container, GridViewColumn column) {
        ASPxCheckBox checkBox = new ASPxCheckBox();
        container.Controls.Add(checkBox);
        checkBox.Text = GetColumnCaption(column);
        checkBox.Checked = column.Visible;
        checkBox.ClientSideEvents.CheckedChanged = CreateCheckedChangedEventHandler(column);
    }

    // Utils
    private string CreateCheckedChangedEventHandler(GridViewColumn column) {
        return string.Format("function(s, e) {{ Cvm_OnCheckedChanged('{0}', '{1}', s); }}", GridView.ClientID, GetColumnName(column));
    }
    private string GetColumnName(GridViewColumn column) {
        if(!string.IsNullOrEmpty(column.Name))
            return column.Name;
        else {
            GridViewDataColumn dataColumn = column as GridViewDataColumn;
            if(dataColumn != null)
                return dataColumn.FieldName;
        }
        return string.Empty;
    }
    private string GetColumnCaption(GridViewColumn column) {
        return !string.IsNullOrEmpty(column.Caption) ? column.Caption : GetColumnName(column);
    }
}