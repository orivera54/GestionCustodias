//jQuery Ready function
//used to bind events for HTML controls
$(function () {
    var cascadingDropDown = new CascadingDropDown();

    //binding change event of the "make" select HTML control
    $('#cod_cliente').on('change', function () {
        var id = $(this).val();    
        //if selected other than default option, make a AJAX call to server
        if (id !== "-1") {
           
            var pagina = '/llavero/TraeOficina/';
            var ruta = pagina.concat(id.toString());       
            $.post(ruta,
                { id: id },
                function (data) {
                    cascadingDropDown.resetCascadingDropDowns();
                    cascadingDropDown.TraeOficinaSucess(data);
                });
        }
        else {
            //reset the cascading dropdown
            cascadingDropDown.resetCascadingDropDowns();
        }
    });

   
});

// Module for CascadingDropDownSample containing JS helper functions
function CascadingDropDown() {
    this.resetCascadingDropDowns = function () {
        this.resetOficinas();
    };
    
    this.TraeOficinaSucess = function (data) {
        //binding JSON data received to HTML select control
        $.each(data, function (key, textValue) {
              $('#cod_ofi').append($('<option />', { value: key, text: textValue }));
        });
        $('#cod_ofi').attr('disabled', false);
    };

   this.resetOficinas = function () {
        $('#cod_ofi option').remove();
        $('#cod_ofi').append($('<option />', { value: '-1', text: 'Por favor seleccione oficina' }));
        $('#cod_ofi').attr('disabled', 'disabled');
    };

   
}