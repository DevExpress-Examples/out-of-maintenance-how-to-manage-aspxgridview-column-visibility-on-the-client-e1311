function Cvm_OnCheckedChanged(gridViewClientID, columnName, columnVisibilitySwitch) {
    var grid = ASPxClientControl.GetControlCollection().Get(gridViewClientID);
    var isColumnVisible = columnVisibilitySwitch.GetChecked();
    var callbackArg = Cvm_CreateCallbackArg(columnName, isColumnVisible);
    grid.PerformCallback(callbackArg);
}
function Cvm_CreateCallbackArg(columnName, isColumnVisible) {
    return "cvm!" + (isColumnVisible ? "1" : "0") + "|" + columnName;
}