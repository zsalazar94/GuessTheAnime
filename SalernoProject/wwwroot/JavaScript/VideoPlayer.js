var videoTimeout;
function hideVideoAndPlay(video, videoSource, filePath, timeout)
{
    clearTimeout(videoTimeout);
    var videoElement = document.getElementById(video);
    var sourceElement = document.getElementById(videoSource);
    sourceElement.src = filePath;
    videoElement.style.display = "none";
    videoElement.load();
    videoElement.play();

    videoTimeout = setTimeout(function () {
        videoElement.pause();
        videoElement.currentTime = 0;
    }, timeout);

}

function showVideoAndPlay(video, videoSource, filePath, dotNetHelper)
{
    clearTimeout(videoTimeout);
    var videoElement = document.getElementById(video);
    var sourceElement = document.getElementById(videoSource);
    sourceElement.src = filePath;
    videoElement.style.display = "block";
    videoElement.load();
    videoElement.play();

    videoTimeout = setTimeout(function () {
        videoElement.pause();
        videoElement.currentTime = 0;
        videoElement.style.display = "none";
        dotNetHelper.invokeMethodAsync("NewOpening");
        
    }, 10000);

}