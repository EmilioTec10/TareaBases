import React, { useState, useEffect } from 'react';
import './reportes.css';

const Reportes = () => {
  const [topPlatosVendidos, setTopPlatosVendidos] = useState(Array(10).fill({}));
  const [topPlatosGanancias, setTopPlatosGanancias] = useState(Array(10).fill({}));
  const [topPlatosFeedback, setTopPlatosFeedback] = useState(Array(10).fill({}));
  const [topClientesOrdenes, setTopClientesOrdenes] = useState(Array(10).fill({}));

  useEffect(() => {
    // Simulación de obtención de datos de los reportes desde una API o almacenamiento local
    const fetchData = async () => {
      // Aquí se puede realizar una llamada a una API o recuperar los datos del almacenamiento local
      // Por ahora, usamos datos simulados
      const topPlatosVendidosData = [
        { id: 1, name: 'Plato 1', quantitySold: 100 },
        { id: 2, name: 'Plato 2', quantitySold: 90 },
        // Agregar más datos aquí
      ];
      setTopPlatosVendidos(topPlatosVendidosData);

      const topPlatosGananciasData = [
        { id: 1, name: 'Plato 1', earnings: 1000 },
        { id: 2, name: 'Plato 2', earnings: 900 },
        // Agregar más datos aquí
      ];
      setTopPlatosGanancias(topPlatosGananciasData);

      const topPlatosFeedbackData = [
        { id: 1, name: 'Plato 1', feedbackScore: 4.5 },
        { id: 2, name: 'Plato 2', feedbackScore: 4.3 },
        // Agregar más datos aquí
      ];
      setTopPlatosFeedback(topPlatosFeedbackData);

      const topClientesOrdenesData = [
        { id: 1, name: 'Cliente 1', ordersCount: 20 },
        { id: 2, name: 'Cliente 2', ordersCount: 18 },
        // Agregar más datos aquí
      ];
      setTopClientesOrdenes(topClientesOrdenesData);
    };

    fetchData();
  }, []);

  return (
    <div className="reportes-container">
      <h1>Vista de Reportes</h1>
      <div className="reportes-section">
        <h2>Top 10 de los platos más vendidos</h2>
        <ul>
          {topPlatosVendidos.map((plato) => (
            <li key={plato.id}>
              <span className="plato-name">{plato.name}</span>
              <span className="plato-quantity">{plato.quantitySold} vendidos</span>
            </li>
          ))}
        </ul>
      </div>
      <div className="reportes-section">
        <h2>Top 10 de los platos que más ganancias generan</h2>
        <ul>
          {topPlatosGanancias.map((plato) => (
            <li key={plato.id}>
              <span className="plato-name">{plato.name}</span>
              <span className="plato-earnings">${plato.earnings}</span>
            </li>
          ))}
        </ul>
      </div>
      <div className="reportes-section">
        <h2>Top 10 de los platos con mejor feedback</h2>
        <ul>
          {topPlatosFeedback.map((plato) => (
            <li key={plato.id}>
              <span className="plato-name">{plato.name}</span>
              <span className="plato-feedback">{plato.feedbackScore} estrellas</span>
            </li>
          ))}
        </ul>
      </div>
      <div className="reportes-section">
        <h2>Top 10 de los clientes que más órdenes han generado</h2>
        <ul>
          {topClientesOrdenes.map((cliente) => (
            <li key={cliente.id}>
              <span className="cliente-name">{cliente.name}</span>
              <span className="cliente-orders">{cliente.ordersCount} órdenes</span>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default Reportes;
