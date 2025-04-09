$(document).ready(function () {
    $('.js-delete').on('click', function () {
        const swalButton = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger mx-2",
                cancelButton: "btn btn-light"
            },
            buttonsStyling: false
        });

        swalButton.fire({
            title: "Are you sure that you need to delete this game?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                var btn = $(this)
                console.log(btn.data('id'))
                $.ajax({
                    url: `/Games/Delete/${btn.data('id')}`,
                    method: "DELETE",
                    success: function () {
                        swalButton.fire({
                            title: "Deleted!",
                            text: "Game has been deleted.",
                            icon: "success"
                        });

                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swalButton.fire({
                            title: "Oooops...!",
                            text: "Somthing went wrong.",
                            icon: "error"
                        });
                    }
                });


            }

        });


    })
})