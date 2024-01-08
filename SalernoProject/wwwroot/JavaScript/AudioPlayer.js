function setAudioSourceAndPlay(audio, audioSource, filePath, timeout)
{
    var audioElement = document.getElementById(audio);
    var sourceElement = document.getElementById(audioSource);
    sourceElement.src = filePath;
    audioElement.load();
    audioElement.play();

    setTimeout(function () {
        audioElement.pause();
        audioElement.currentTime = 0;
    }, timeout);
}