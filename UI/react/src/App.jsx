import React, { useState, useEffect } from 'react';
import Botao from './components/botao/botao';
import MonitorAntigo from './components/monitor/monitor';
import './App.css';

function App() {
  const [dadosAPI, setDadosAPI] = useState([]);
  const [selectedAction, setSelectedAction] = useState(null);
  const [status, setStatus] = useState('');
  const [lastActionOrder, setLastActionOrder] = useState(null);
  const [lastActionName, setLastActionName] = useState(null);

  const buscarDadosAPI = async () => {
    try {
      const resposta = await fetch('https://localhost:7032/api/Robo');
      if (!resposta.ok) {
        throw new Error('Erro na resposta da API');
      }
      const dados = await resposta.json();
      setDadosAPI(dados);
    } catch (error) {
      console.error('Erro ao buscar dados da API:', error);
    }
  };

  const handleActionClick = (action) => {
    // Salvar a ação anterior
    setLastActionOrder(selectedAction ? selectedAction.action_Order : null);
    setLastActionName(selectedAction ? selectedAction.action : null);

    setSelectedAction(action);
    sendAction(action);
  };

  const sendAction = async (action) => {
    try {
      if (!action) {
        throw new Error('Ação não definida.');
      }

      const url = buildApiUrl(action);

      const requestBody = {
        body_Name: action.body_Name,
        body_Item_Name: action.body_Item_Name,
        side: action.side,
        action_Order: action.action_Order,
        action: action.action
      };

      if (!requestBody.side || !requestBody.action || !requestBody.body_Name || !requestBody.body_Item_Name) {
        throw new Error('Campos obrigatórios não estão definidos.');
      }

      const resposta = await fetch(url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(requestBody)
      });

      if (!resposta.ok) {
        throw new Error('Erro ao enviar dados para a API');
      }

      const dados = await resposta.json();

      if (dados === true) {
        setStatus('Sua ação foi realizada com sucesso.');
      } else {
        setStatus('Uma operação ilegal foi realizada.');
      }
    } catch (error) {
      console.error('Erro ao enviar dados para a API:', error);
      setStatus('Erro ao enviar dados para a API.');
    }
  };

  const buildApiUrl = (action) => {
    const baseUrl = 'https://localhost:7032/api/Robo';
    const params = [];

    if (lastActionOrder) {
      params.push(`LasActionOrder=${lastActionOrder}`);
    }

    if (lastActionName) {
      params.push(`LastAction=${lastActionName}`);
    }

    if (params.length > 0) {
      return `${baseUrl}?${params.join('&')}`;
    }

    return baseUrl;
  };

  const filterItems = (dadosAPI, bodyName, bodyItemName, side) => {
    return dadosAPI.filter(item =>
      item.body_Name === bodyName &&
      item.body_Item_Name === bodyItemName &&
      item.side === side
    );
  };

  useEffect(() => {
    buscarDadosAPI();
  }, []);

  return (
    <div className="App">
      <div className='monitor'>
        <MonitorAntigo
          bodyName={selectedAction ? `${selectedAction.body_Name} - ${selectedAction.body_Item_Name}` : ''}
          bodyAction={selectedAction ? selectedAction.action : ''}
          status={status}
        />
      </div>
      <div className='painel'>
      <div className='controles'>
        <h3>Cotovelo - Direito</h3>
        <div className='botoes'>
          {filterItems(dadosAPI, "BRACO", "COTOVELO", "DIREITO").map(item => (
            <Botao className="botao" key={item.id} value={item.action} onClick={() => handleActionClick(item)}>{item.action}</Botao>
          ))}
        </div>
      </div>
      <div className='controles'>
      <h3>Cotovelo - Esquerdo</h3>
      <div className='botoes'>
          {filterItems(dadosAPI, "BRACO", "COTOVELO", "ESQUERDO").map(item => (
            <Botao className="botao" key={item.id} value={item.action} onClick={() => handleActionClick(item)}>{item.action}</Botao>
          ))}
        </div>
      </div>
      <div className='controles'>
      <h3>Punho - Direito</h3>
      <div className='botoes'>
          {filterItems(dadosAPI, "BRACO", "PULSO", "DIREITO").map(item => (
            <Botao className="botao" key={item.id} value={item.action} onClick={() => handleActionClick(item)}>{item.action}</Botao>
          ))}
        </div>
      </div>
      <div className='controles'>
      <h3>Punho - Esquesdo</h3>
      <div className='botoes'>
          {filterItems(dadosAPI, "BRACO", "PULSO", "DIREITO").map(item => (
            <Botao className="botao" key={item.id} value={item.action} onClick={() => handleActionClick(item)}>{item.action}</Botao>
          ))}
        </div>
      </div>
      <div className='controles'>
      <h3>Cabeça - Rotação</h3>
      <div className='botoes'>
          {filterItems(dadosAPI, "CABECA", "CABECA", "ROTACAO").map(item => (
            <Botao className="botao" key={item.id} value={item.action} onClick={() => handleActionClick(item)}>{item.action}</Botao>
          ))}
        </div>
      </div>
      <div className='controles'>
      <h3>Cabeça - Inclinação</h3>
      <div className='botoes'>
          {filterItems(dadosAPI, "CABECA", "CABECA", "INCLINACAO").map(item => (
            <Botao className="botao" key={item.id} value={item.action} onClick={() => handleActionClick(item)}>{item.action}</Botao>
          ))}
        </div>
      </div>
    </div>
    </div>
  );
}

export default App;
