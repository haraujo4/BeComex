import { useState, useEffect } from 'react'
import Botao from './components/botao/botao'
import MonitorAntigo from './components/monitor/monitor'

function App() {
  const [dadosAPI, setDadosAPI] = useState({});

  const buscarDadosAPI = async () => {
    try {
      const resposta = await fetch('http://localhost:5079/api/Robo');
      const dados = await resposta.json();
      setDadosAPI(dados);
    } catch (error) {
      console.error('Erro ao buscar dados da API:', error);
    }
  };
  console.log(buscarDadosAPI())

  useEffect(() => {
    buscarDadosAPI();
  }, []);

  return (
    <>
      <div className="App">
          <div>
            <h1>{buscarFuncoesBotao()}</h1>
          </div>
      </div>
    </>
  )
}

export default App
