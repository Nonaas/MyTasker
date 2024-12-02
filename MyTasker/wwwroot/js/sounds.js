function SetupPlayer() {
    const audioPlayer = document.getElementById("audioPlayer");
    const seekBarLabel = document.getElementById("seekBarLabel");

    if (audioPlayer) {
        // Attach callbacks
        audioPlayer.ontimeupdate = function () {
            UpdateSeekBar();
            UpdateSeekBarLabel();
        };

        audioPlayer.ondurationchange = UpdateSeekBarLabel;

        console.log("Audio player is ready, and ontimeupdate event is attached.");
    } else {
        console.error("Audio player element not found.");
    }
}

function UpdateSeekBarLabel() {
    const audioPlayer = document.getElementById("audioPlayer");
    const seekBarLabel = document.getElementById("seekBarLabel");

    if (audioPlayer && seekBarLabel) {
        const currentTime = FormatTime(audioPlayer.currentTime);
        const duration = FormatTime(audioPlayer.duration);

        seekBarLabel.textContent = `${currentTime} / ${duration}`;
    }
}

function FormatTime(seconds) {
    if (isNaN(seconds) || seconds === Infinity) return "00:00";

    const minutes = Math.floor(seconds / 60);
    const secs = Math.floor(seconds % 60);

    return `${minutes.toString().padStart(2, "0")}:${secs.toString().padStart(2, "0")}`;
}

function LoadAudioPlayer() {
    const audioPlayer = document.getElementById("audioPlayer");

    try {
        // Load the audio
        audioPlayer.load();

    } catch (e) {
        console.error("Error loading audio:", e);
    }
}

// Custom player controls
function PlayAudio() {
    const audioPlayer = document.getElementById("audioPlayer");
    audioPlayer.load();
    audioPlayer.play().catch((e) => console.error("Error playing audio:", e));
}

function PauseAudio() {
    const audioPlayer = document.getElementById("audioPlayer");
    audioPlayer.pause();
}

function StopAudio() {
    const audioPlayer = document.getElementById("audioPlayer");
    audioPlayer.currentTime = 0; // Reset to start
    audioPlayer.pause();
    audioPlayer.load();
}

function UpdateSeekBar() {
    const audioPlayer = document.getElementById("audioPlayer");
    const seekBar = document.getElementById("seekBar");

    if (audioPlayer && seekBar) {
        seekBar.value = (audioPlayer.currentTime / audioPlayer.duration) * 100;
    }
}
