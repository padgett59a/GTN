
//        function waitSeconds(iMilliSeconds) {
//        function digitsOnly(checkStr) {
//        function alphaOnly(checkStr) {
//        function removeRow(evt) {
//        function getCBhtml(bChecked, bDisabled) {
//        function decodeHtml(html) {
//        function changeSaveButton(changeTo, selCurr ) {



<script type="text/javascript">


        function waitSeconds(iMilliSeconds) {
            var counter = 0
                , start = new Date().getTime()
                , end = 0;
            while (counter < iMilliSeconds) {
                end = new Date().getTime();
                counter = end - start;
            }
        }


</script>