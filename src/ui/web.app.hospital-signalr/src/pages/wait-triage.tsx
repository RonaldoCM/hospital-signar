import { useEffect, useState } from "react";
import { Patient } from "../types/patient";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

export const WaitTriage = () => {
  const [patient, setPatient] = useState<Patient>();

  useEffect(() => {
    startConnectionHub();
  }, []);

  const startConnectionHub = async () => {
    console.log('iniciando conexão com o Hub...');
    const connection = new HubConnectionBuilder()
    .withUrl("http://localhost:5184/hub/triage")
    .configureLogging(LogLevel.Information)
    .build();

    connection.on("TriageNotification", (data) => {
      setPatient(data);
    });
    await connection.start();
  }
  
    return (
      <>
        <p>Favor ir para sala de triagem, paciente:</p>
        <h1>{patient?.name}</h1>
        <h3><b>Código de Atendimento: </b>{patient?.code}</h3>
      </>
    )
  }