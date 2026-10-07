window.showAlert = (title, text, icon) => {
    Swal.fire({
        title: title,
        text: text,
        icon: icon,
        confirmButtonText: 'OK'
    });
};


window.showDeleteConfirmation = (title, text) => {
    return Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Delete',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        return result.isConfirmed; // Returns true if the user confirmed the action
    });
};