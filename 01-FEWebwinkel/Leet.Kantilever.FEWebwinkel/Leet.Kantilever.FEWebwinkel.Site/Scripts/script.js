$(document).ready(function () {
    $('.mandBtn').click(function (eOpts) {
        // Get the clicked button
        var $old = $(this);             
        // Copy the element to the winkelmand element
        var $new = $old.clone().appendTo('#winkelmand-target');
        var newOffset = $new.offset();
        // Get the old position relative to document
        var oldOffset = $old.offset();
        // We also clone old to the document for the animation
        var $temp = $old.clone().appendTo('body');
        // Hide the new element when it is in position
        $temp
          .css('position', 'absolute')
          .css('left', oldOffset.left)
          .css('top', oldOffset.top)
          .css('zIndex', 1000);
        $new.hide();
        // animate the $temp to the winkelmand position
        $temp.animate({ 'top': newOffset.top, 'left': newOffset.left, 'height': 0, 'width': 0 }, 'slow', function () {
            // callback function, remove the temp element
            $temp.remove();
        });

        // Split 'prod-' from 'prod-123'
        var productId = this.id.split('-')[1];
        $('#winkelmand-counter').html(+$('#winkelmand-counter').html() + 1);
    });
});