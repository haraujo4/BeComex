import React from 'react';
import './estilo.css'; // Importe o arquivo CSS

const MonitorAntigo = ({ dadosAPI }) => {
  return (
    <div className="monitor"> {/* Use a classe CSS 'monitor' */}
      <h2>Monitor Antigo</h2>
      <p>Dados da API:</p>
      <pre>{JSON.stringify(dadosAPI, null, 2)}</pre>
    </div>
  );
};

export default MonitorAntigo;
