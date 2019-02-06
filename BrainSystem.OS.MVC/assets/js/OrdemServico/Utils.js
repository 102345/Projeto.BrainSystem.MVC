    $(document).ready(function ($) {
        $(".table-row").click(function () {
            MostrarSpinner('tblProdutosFalhados');
            window.document.location = $(this).data("href");
        });
    });

    function AbrirURL(url) {
        $(location).attr('href', url);
    }


    $(function () {
        var displayMessage = function (message, msgType) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-top-center",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "100",
                "hideDuration": "1000",
                "timeOut": "4000",
                "extendedTimeOut": "2000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };
            toastr[msgType](message);
        };

        if ($('#success').val()) {
            displayMessage($('#success').val(), 'success');
        }
        if ($('#info').val()) {
            displayMessage($('#info').val(), 'info');
        }
        if ($('#warning').val()) {
            displayMessage($('#warning').val(), 'warning');
        }
        if ($('#error').val()) {
            displayMessage($('#error').val(), 'error');
        }
    });


    function MostrarSpinner(element) {

        var opts = {
            lines: 13 // The number of lines to draw
            , length: 7 // The length of each line
            , width: 3 // The line thickness
            , radius: 7 // The radius of the inner circle
            , scale: 0.25 // Scales overall size of the spinner
            , corners: 1 // Corner roundness (0..1)
            //, color: '#000' // #rgb or #rrggbb or array of colors
            , color: '#428bca'
            , opacity: 0.25 // Opacity of the lines
            , rotate: 0 // The rotation offset
            , direction: 1 // 1: clockwise, -1: counterclockwise
            , speed: 1 // Rounds per second
            , trail: 60 // Afterglow percentage
            , fps: 20 // Frames per second when using setTimeout() as a fallback for CSS
            , zIndex: 2e9 // The z-index (defaults to 2000000000)
            , className: 'spinner' // The CSS class to assign to the spinner
            , top: '50%' // Top position relative to parent
            , left: '50%' // Left position relative to parent
            , shadow: false // Whether to render a shadow
            , hwaccel: false // Whether to use hardware acceleration
            , position: 'absolute' // Element positioning
        }


        var target = document.getElementById(element);
        var spinner = new Spinner(opts).spin(target);

     


    }

            
            
    //Ladda.bind('input[type=submit]');
            
    //var l = Ladda.create(document.querySelector('button'));
    //l.stop();

    //function IniciarLoader()
    //{
              
    //    var l = Ladda.create(document.querySelector('button'));

    //    l.start();


    //}
            
           

    // You can control loading explicitly using the JavaScript API
    // as outlined below:

          
    //
    // l.stop();
    // l.toggle();
    // l.isLoading();
    // l.setProgress( 0-1 );

