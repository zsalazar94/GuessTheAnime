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