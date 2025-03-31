import { useState } from "react";
import * as api from '../services/api';
import * as hub from '../services/hub';
import { Patient } from "../types/patient";

export const MedicalCare = () => {
  const [patient, setPatient] = useState<Patient>();
  const getNextPatient = async () => {
    const response = await api.get<Patient>('medicalCare/next');
    setPatient(response);
    response && startConnectionHub(response);
  }

  const startConnectionHub = async (parameter: Patient) => {
    const connection = hub.newConnection('medicalCare');
    await connection.start();
    connection.invoke("CallMedicalCare", parameter);
  }
  
  return (
    <>
      <button onClick={getNextPatient} style={{marginBottom: '20px'}}>Chamar Próximo Paciente</button>
      {patient && <label><b>Código de Atendimento:: </b> {patient.code}</label>}
      {patient && <label><b>Paciente: </b> {patient.name}</label>}
      
      <form onSubmit={async (e) => {
          e.preventDefault();
      }}>
      </form>
    </>
  )
}