var contactForm = contactForm ||
{
    init: function() {
        this.listeners();
    },
    listeners: function(e) {
        $(document).on('click',
            '.contact-submit',
            function(e) {
                var form = $("#contact-form");
                form.submit();
                e.preventDefault();
            });
    },
    showResult: function () {
        $("#form-outer").hide('slow');
        $("#form-result").show('slow');
    }

}