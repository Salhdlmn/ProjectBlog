$(document).ready(function () {
    $('#commentForm').submit(function (e) {
        e.preventDefault();

        var formData = $(this).serialize();

        $.ajax({
            url: '/Comment/AddComment',
            type: 'POST',
            data: formData,
            success: function (response) {
                if (response.success) {
                    alert("Yorum gönderildi!");
                    location.reload();
                } else {
                    alert("Yorum gönderilemedi! " + response.message);
                }
            },
            error: function () {
                alert("Yorum gönderilemedi! (ajax error)");
            }
        });
    });
});
