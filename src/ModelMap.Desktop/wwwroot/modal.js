export function show(id) {
  const modal = new bootstrap.Modal(document.getElementById(id));
  if (modal) {
    modal.show();
  }
}

export function hide(id) {
  const modal = bootstrap.Modal.getInstance(document.getElementById(id));
  if (modal) {
    modal.hide();
  }
}