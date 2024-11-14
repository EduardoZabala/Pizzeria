// popup.js

function mostrarPopup() {
    Swal.fire({
        title: '<div class="popup-titulo">Selecciona pizza para La Reunión Perfecta</div>',
        html: `
            <div class="popup-container">
                <div class="popup-card">
                    <div class="promocion-imagen"><img src="images/cuatro quesos.jpeg" class="promocion-imagen" /></div>
                    <h3>Pizza Cuatro Quesos</h3>
                    <button>Agregar al carrito</button>
                </div>
                <div class="popup-card">
                    <div class="promocion-imagen"><img src="images/vegetar.jpeg" class="promocion-imagen" /></div>
                    <h3>Pizza Vegetariana</h3>
                    <button>Agregar al carrito</button>
                </div>
                <div class="popup-card">
                    <div class="promocion-imagen"><img src="images/ranchera.jpeg" class="promocion-imagen" /></div>
                    <h3>Pizza Ranchera</h3>
                    <button>Agregar al carrito</button>
                </div>
                <div class="popup-card">
                    <div class="promocion-imagen"><img src="images/hawaiana .jpeg" class="promocion-imagen" /></div>
                    <h3>Pizza Hawaiana</h3>
                    <button>Agregar al carrito</button>
                </div>
            </div>
            <button class="popup-back-button" onclick="Swal.close()">Regresar</button>
        `,
        showConfirmButton: false,
        width: '800px', // Ancho del popup
        padding: '20px',
        background: '#FF5A5F',
    });
}
