<script>
    function SearchScript() {
        // Объявить переменные
        var input, filter, ul, li, a, i;
        input = document.getElementById("SearchScript");
        filter = input.value.toUpperCase();
        ul = document.getElementById("myMenu");
        li = ul.getElementsByTagName("li");

        // Перебирайте все элементы списка и скрывайте те, которые не соответствуют поисковому запросу
        for (i = 0; i < li.length; {
        a = li[i].getElementsByTagName("a")[0];
            if(a.innerHTML.toUpperCase().indexOf(filter) > -1) {
        li[i].style.display = "";
        } else {
        li[i].style.display = "none";
        }
    }
}
</script>