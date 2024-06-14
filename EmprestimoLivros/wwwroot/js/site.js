$(document).ready(function () {
    $('#Emprestimos').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "Nenhum dado disponível na tabela",
            "info": "Mostrando _START_ até _END_ de _TOTAL_ entradas",
            "infoEmpty": "Mostrando 0 até 0 de 0 entradas",
            "infoFiltered": "(filtrado de _MAX_ entradas no total)",
            "infoPostFix": "",
            "thousands": ".",
            "lengthMenu": "Mostrar _MENU_ entradas",
            "loadingRecords": "Carregando...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "Nenhum registro correspondente encontrado",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Ordenar por esta coluna",
                "orderableReverse": "Ordenar reversamente por esta coluna"
            }
        }
    });

    setTimeout(function () {
      
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close')
        })
    }, 3000);
     
});



   
       

