function toggleChatbot() {
    const toggleButton = document.getElementById('toggle-button');
    const chatbotContainer = document.getElementById('chatbot-container');
    chatbotContainer.style.display = 'none'; /*written for display in single click issue*/
    if (chatbotContainer.style.display == 'none') {
        chatbotContainer.style.display = 'block'
    }
    else {
        chatbotContainer.style.display = 'none'
    }
}
function closeChatbot() {
    const closeBtn = document.getElementById('button-close');
    const chatbotContainer = document.getElementById('chatbot-container');
    chatbotContainer.style.display = 'none'
}
function selectLang() {

    let iframeEnglish = document.getElementById("webchatEnglish");
    let iframeMarathi = document.getElementById("webchatMarathi");

    let selectedLang = document.getElementById("lang").value;

    if (selectedLang == 'English') {
        iframeEnglish.style.display = "block";
        iframeMarathi.style.display = "none";
    } else if (selectedLang == 'Marathi') {
        iframeMarathi.style.display = "block";
        iframeEnglish.style.display = "none";
    }
}
//function resetChatbot() {
//    let resetEnglishFrame = document.getElementById("iframe-English");
//    let resetMarathiFrame = document.getElementById("iframe-Marathi");
//    resetEnglishFrame.src = "https://webchat.botframework.com/embed/chatbot-ph-eng?s=vmW3PB-bxsQ.wyxuNU6MI0CAPmKDUAZdAdcNbLUX08m2q_SDrDLxDa4";
//    resetMarathiFrame.src = "https://webchat.botframework.com/embed/chatbot-ph-mr?s=nPC2Qe804CM.xfycmONT6iZbaHz7aE1h0ls-Isc5RH8uNmjQjlvaWSw";
//}