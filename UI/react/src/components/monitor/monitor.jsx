import React from 'react';
import './estilo.css'; // Importe o arquivo CSS

const MonitorAntigo = (props) => {
  return (
    <div className="monitor"> {/* Use a classe CSS 'monitor' */}
      <h1>Controle do R.O.B.O</h1>
      <h2>{props.bodyName}</h2>
      <h2>{props.bodyAction}</h2>
      <h3>{props.status}</h3>
    </div>
  );
};

export default MonitorAntigo;
