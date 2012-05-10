/// --------------------------------------------------
/// mainScreen object
/// --------------------------------------------------
var mainScreen = 
{
    resultDivId : "resultDiv",
    resultDiv : null
}

mainScreen.Init = function() {
    /// <summary>
    /// Initializes mainScreen variables
    /// </summary>
    this.resultDiv = $get(this.resultDivId);
};
mainScreen.GetRow = function () {
    /// <summary>
    /// Loads rendered server control from server
    /// </summary>
    PageMethods.GetRow();
};



/// --------------------------------------------------
/// Page events processing
/// --------------------------------------------------

Sys.Application.add_load(applicationLoadHandler);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequestHandler);

function applicationLoadHandler() {
    /// <summary>
    /// Raised after all scripts have been loaded and 
    /// the objects in the application have been created 
    /// and initialized.
    /// </summary>
    mainScreen.Init()
}

function endRequestHandler() {
    /// <summary>
    /// Raised before processing of an asynchronous 
    /// postback starts and the postback request is 
    /// sent to the server.
    /// </summary>
    
    // TODO: Add your custom processing for event
}

function beginRequestHandler() {
    /// <summary>
    /// Raised after an asynchronous postback is 
    /// finished and control has been returned 
    /// to the browser.
    /// </summary>

    // TODO: Add your custom processing for event
}