document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.collapseButton').forEach(function (button) {
        button.addEventListener('click', function () {
            setTimeout(() => {
                var invoiceId = $(this).data('invoice-id');

                if (button.classList.contains('collapsed')) {
                    button.classList.remove('bi-chevron-double-up');
                    button.classList.add('bi-chevron-double-down');

                    document.getElementById(`printButton_${invoiceId}`).toggleAttribute("hidden");
                    document.getElementById(`correctionButton_${invoiceId}`).toggleAttribute("hidden");

                } else {
                    button.classList.remove('bi-chevron-double-down');
                    button.classList.add('bi-chevron-double-up');

                    document.getElementById(`printButton_${invoiceId}`).toggleAttribute("hidden");
                    document.getElementById(`correctionButton_${invoiceId}`).toggleAttribute("hidden");
                }
            }, 350);
        });
    });
});