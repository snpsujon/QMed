window.initializeTrixEditor = () => {
    const editorElement = document.getElementById("trix-editor");
    editorElement.addEventListener("trix-change", () => {
        const content = editorElement.value; // Use editorElement to get value
        DotNet.invokeMethodAsync("QuickMedBlazor.Components.TrixEditor", "UpdateContent", content);
    });
};
