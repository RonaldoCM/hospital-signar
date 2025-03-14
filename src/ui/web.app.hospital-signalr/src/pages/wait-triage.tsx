import { useEffect, useState } from "react";
import { Patient } from "../types/patient";
import * as hub from '../services/hub';

export const WaitTriage = () => {
  const [patient, setPatient] = useState<Patient>();

  useEffect(() => {
    startConnectionHub();
  }, []);

  const startConnectionHub = async () => {
    const connection = hub.newConnection('triage');

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