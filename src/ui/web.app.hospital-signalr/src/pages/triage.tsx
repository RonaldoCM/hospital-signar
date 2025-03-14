import { useState } from "react";
import * as api from '../services/api';
import { Patient } from "../types/patient";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

export const Triage = () => {
  const [patient, setPatient] = useState<Patient>();
  const getNextPatient = async () => {
    const response = await api.get<Patient>('triage/next');
    setPatient(response);
    response && startConnectionHub(response);
  }

  const startConnectionHub = async (parameter: Patient) => {
    console.log('iniciando conexão com o Hub...');
    const connection = new HubConnectionBuilder()
    .withUrl("http://localhost:5184/hub/triage")
    .configureLogging(LogLevel.Information)
    .build();

    await connection.start();
    connection.invoke("CallTriage", parameter);
  }
  
  return (
    <>
      <button onClick={getNextPatient} style={{marginBottom: '20px'}}>Chamar Próximo</button>
      {patient && <label><b>Código de Atendimento:: </b> {patient.code}</label>}
      {patient && <label><b>Paciente: </b> {patient.name}</label>}
      
      <form onSubmit={async (e) => {
          e.preventDefault();
      }}>
        <div>
          <select id="rate" style={{padding: '7px 3px', marginBottom: '20px'}}>
            <option value="0">Azul</option>
            <option value="1">Verde</option>
            <option value="2">Azul</option>
            <option value="3">Vermelho</option>
          </select>
        </div>
        <div>
          <button type="submit">Avaliar</button>
        </div>
      </form>
    </>
  )
}