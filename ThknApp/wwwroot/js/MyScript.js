let filter = function () {
    let input = document.getElementById('filter_input');

    input.addEventListener('keyup', function () {
        let filter = input.value.toLowerCase(),
            filterElements = document.querySelectorAll('.filter_List');


        filterElements.forEach(item => {
            if (item.innerHTML.toLowerCase().indexOf(filter) > -1) {
                item.style.display = '';
            } else {
                item.style.display = 'none';
            }
        })


    })



};

filter();