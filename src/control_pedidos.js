import React, { useState, useEffect } from 'react';
import './control_pedidos.css';

const Control_Pedidos = () => {
  const [order, setOrder] = useState({ dish: 'Pizza' });
  const [progress, setProgress] = useState(0);

  useEffect(() => {
    const timer = setTimeout(() => {
      if (progress < 100) {
        setProgress(progress + 10);
      }
    }, 3000);

    return () => clearTimeout(timer);
  }, [progress]);

  return (
    <div className="chefOrdersContainer">
      <h2>Orden Pendiente</h2>
      <hr className="divider" />
      <div className="orderDetails">
        <div className="orderInfo">
          <span>Nombre del Plato:</span>
          <span>{order.dish}</span>
        </div>
        <div className="progressBar">
          <div className="progress" style={{ width: `${progress}%` }} />
        </div>
        <div className="progressText">
          {progress === 0 && <span>Preparando Pedido...</span>}
          {progress > 0 && progress < 100 && <span>Enviando Pedido...</span>}
          {progress === 100 && <span>Pedido Enviado</span>}
        </div>
      </div>
    </div>
  );
};

export default Control_Pedidos;
