import React from 'react';
import './vista_chef.css'; // Importar estilos CSS

const Vista_Chef = () => {
  const handleButtonClick = (path) => {
    window.location.href = path;
  };

  return (
    <div className="adminContainer">
      <h1>Bienvenido a la Vista de Chef</h1>
      <div className="buttonContainer">
        <button className="adminButton" onClick={() => handleButtonClick('/ordenes_chef')}>1. Tomar pedidos</button>
        <button className="adminButton" onClick={() => handleButtonClick('/control_pedidos')}>2. Control de pedidos</button>
        <button className="adminButton" onClick={() => handleButtonClick('/reportes')}>3. Reasignar un pedido</button>
      </div>
    </div>
  );
};

export default Vista_Chef;
