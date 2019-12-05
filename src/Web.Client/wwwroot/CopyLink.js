window.CopyLink =
{
    CopyLink: function() {
        var emailLink = document.querySelector(".js-copylink");
        var range = document.createRange();
        range.selectNode(emailLink);
        window.getSelection().addRange(range);
        try {

            var successful = document.execCommand("copy");
            var msg = successful ? "successful" : "unsuccessful";
            console.log("Copy email command was " + msg);
        } catch (err) {
            console.log("Oops, unable to copy");
        }
        window.getSelection().removeAllRanges();
    }
};