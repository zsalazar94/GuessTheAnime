function scrollToBottom() {
    var messagesList = document.getElementById('messagesList');
    messagesList.scrollTop = messagesList.scrollHeight;
}

function checkIfAtBottomOfChat() {
    var messagesList = document.getElementById('messagesList');
    var shouldScroll = messagesList.scrollHeight - messagesList.scrollTop === messagesList.clientHeight;
    return shouldScroll;
}

function blurElementById(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.blur();
    }
}

function focusElementById(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
}