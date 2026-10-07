//window.initializeQuill = (editorId) => {
//    const quill = new Quill(editorId, {
//        theme: 'snow'
//    });
//};


window.initializeQuill = (editorId) => {
    function tryInitializeQuill() {
        const editorElement = document.querySelector(editorId);
        if (editorElement) {
            new Quill(editorId, { theme: 'snow' });
        } else {
            // Retry after a short delay if editorId is not found
            setTimeout(tryInitializeQuill, 100); // retry every 100ms
        }
    }
    tryInitializeQuill();
};




window.initializeSelect2 = (id, placeHolder, isFreeText = false) => {
    $('#' + id).select2({
        tags: isFreeText, // Allows free-text input
        placeholder: placeHolder,
        allowClear: true
    });
};


window.showLoading = function () {
    const overlay = document.getElementById('loadingOverlay');
    if (overlay) {
        overlay.classList.add('active');
    } else {
        console.error("Loading overlay element not found.");
    }
};

window.initializeSelect2WithBlazor = function (selectElement, dotNetHelper) {
    // Initialize Select2
    $(selectElement).select2({
        placeholder: 'Please Select',
        allowClear: true
    });

    // When the value changes, invoke the Blazor method
    $(selectElement).on('change', function () {
        var selectedValue = $(this).val();
        dotNetHelper.invokeMethodAsync('OnTreatmentTemplateChange', selectedValue);
    });
};


window.uploadFile = async (element) => {
    const file = element.files[0];
    if (file) {
        return new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.onload = () => {
                const base64String = btoa(String.fromCharCode(...new Uint8Array(reader.result)));
                resolve(base64String);  // Resolving with base64 encoded string
            };
            reader.onerror = reject;
            reader.readAsArrayBuffer(file);
        });
    } else {
        throw new Error("No file selected");
    }
};

window.initializeDevExtremeDataGrid = function (data) {
    $("#devextreme-datagrid").dxDataGrid({
        data,
        columns: ["Actions", "Name", "Age", "Gender", "Address", "Mobile", "Code", "Admission Date"]
    });
}




window.initializeTextareaAutocomplete = (dotNetHelper) => {
    const textarea = document.getElementById('autocomplete-textarea');
    const suggestionsPanel = document.getElementById('suggestions-panel');

    textarea.addEventListener('input', async (e) => {
        const input = e.target.value;
        const lastWord = input.split(' ').pop();

        if (lastWord.length > 1) {
            const suggestions = await dotNetHelper.invokeMethodAsync('GetSuggestions', lastWord);
            suggestionsPanel.innerHTML = '';
            suggestions.forEach(suggestion => {
                const div = document.createElement('div');
                div.innerHTML = suggestion;
                div.addEventListener('click', () => {
                    const words = textarea.value.split(' ');
                    words.pop();
                    words.push(suggestion);
                    textarea.value = words.join(' ') + ' ';
                    suggestionsPanel.innerHTML = '';
                });
                suggestionsPanel.appendChild(div);
            });
        } else {
            suggestionsPanel.innerHTML = '';
        }
    });
};


window.initializeSelect2WithTagCreate = (id, placeHolder, dotNetHelper, isFreeText = false) => {
    $('#' + id).select2({
        tags: isFreeText, // Allows free-text input
        placeholder: placeHolder,
        allowClear: true
    }).on('change', function () {
        var selectedValue = $(this).val();
        dotNetHelper.invokeMethodAsync('OnTagSavetoDB', selectedValue, id);
    });
};
function downloadFileFromBytes(fileName, base64Content) {
    const link = document.createElement('a');
    link.href = `data:application/pdf;base64,${base64Content}`;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}