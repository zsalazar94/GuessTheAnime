var videoTimeout;
function hideVideoAndPlay(video, timeout)
{
    clearTimeout(videoTimeout);
    var videoElement = document.getElementById(video);
    videoElement.style.display = "none";
    videoElement.load();
    videoElement.play();

    videoTimeout = setTimeout(function () {
        videoElement.pause();
        videoElement.currentTime = 0;
    }, timeout);

}

function showVideoAndPlay(video, dotNetHelper)
{
    clearTimeout(videoTimeout);
    var videoElement = document.getElementById(video);
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

function pauseVideo(video) {
    clearTimeout(videoTimeout);
    var videoElement = document.getElementById(video);
    videoElement.style.display = "none";
    videoElement.pause();
}