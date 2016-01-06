$(document).ready(function () {
    $('.mandBtn').click(function (eOpts) {


        var $old = $(this);
        //First we copy the arrow to the new table cell and get the offset to the document
        var $new = $old.clone().appendTo('#winkelmand-counter');
        var newOffset = $new.offset();
        //Get the old position relative to document
        var oldOffset = $old.offset();
        //we also clone old to the document for the animation
        var $temp = $old.clone().appendTo('body');
        //hide new and old and move $temp to position
        //also big z-index, make sure to edit this to something that works with the page
        $temp
          .css('position', 'absolute')
          .css('left', oldOffset.left)
          .css('top', oldOffset.top)
          .css('zIndex', 1000);
        $new.hide();
        //animate the $temp to the position of the new img
        $temp.animate({ 'top': newOffset.top, 'left': newOffset.left }, 'slow', function () {
            //callback function, we remove $old and $temp and show $new
            $new.show();
            $temp.remove();
        });
        // Split 'prod-' from 'prod-123'
        var productId = this.id.split('-')[1];
        $('#winkelmand-counter').html(+$('#winkelmand-counter').html() + 1);
    });
});