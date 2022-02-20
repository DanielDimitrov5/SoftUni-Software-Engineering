$(function () {
  $('[data-toggle="tooltip"]').tooltip({
    html: true
  })
})

$("#name-input").focusout(function () {
  let name = $("#name-input").val();

  if (name.length != 0) {
      $('#player-name').text(name);
  }
})

$("#image-input").focusout(function () {
  let imageUrl = $("#image-input").val();

  if (imageUrl.length != 0) {
      $('#player-image').attr('src', imageUrl);
  }
})

$("#position-input").focusout(function () {
    $('#player-position').text($("#position-input").val());
})

$("#speed-input").focusout(function () {
    let speed = $("#speed-input").val();

  if (speed.length != 0) {
      $('#player-speed').text(speed);
  }
})

$("#endurance-input").focusout(function () {
    let endurance = $("#endurance-input").val();

  if (endurance.length != 0) {
      $('#player-endurance').text(endurance);
  }
})

$("#description-input").focusout(function () {
    $('#player-name').attr('data-original-title', `Description:<br>${$("#description-input").val()}`);
})