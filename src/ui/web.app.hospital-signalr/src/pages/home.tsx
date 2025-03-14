import { useForm, SubmitHandler } from "react-hook-form"
import * as api from '../services/api';
import { Patient } from "../types/patient";



export const Home = () => {
  const {
      register,
      handleSubmit,
      reset
      } = useForm<Patient>()
      const onSubmit: SubmitHandler<Patient> = async (data) => {
        await api.post('triage', data);
        reset();
      }
  return (
    <>
        <form onSubmit={handleSubmit(onSubmit)}>
            <div style={{margin: '10px 0', fontSize: '24px'}}>
                <label>BEM VINDO AO HOSPITAL-SIGNALR</label>
            </div>
            <div>
                <input {...register('name', {required: true})} placeholder="Nome" />
            </div>
            <div>
                <button type="submit">Cadastrar</button>
            </div>
        </form>
    </>
  )
}