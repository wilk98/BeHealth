import Carousel from "../components/layout/Searcher/Carousel"
import Searcher from "../components/layout/Searcher/Searcher"
import dermatolog from "../assets/images/specializacje/dermatolog.png"
import gastrolog from "../assets/images/specializacje/gastrolog.png"
import ginekolog from "../assets/images/specializacje/ginekolog.png"
import hematolog from "../assets/images/specializacje/hematolog.png"
import hepatolog from "../assets/images/specializacje/hepatolog.png"
import kardiolog from "../assets/images/specializacje/kardiolog.png"
import laryngolog from "../assets/images/specializacje/laryngolog.png"
import neurolog from "../assets/images/specializacje/neurolog.png"
import ogolny from "../assets/images/specializacje/ogolny.png"
import okulista from "../assets/images/specializacje/okulista.png"
import ortopeda from "../assets/images/specializacje/ortopeda.png"
import pediatra from "../assets/images/specializacje/pediatra.png"
import plastyczny from "../assets/images/specializacje/plastyczny.png"
import doctorImage from "../assets/images/doctorExample.png"
import './CategoriesSearch.css'
import { useState } from "react"
import { api_path } from '../utils/api';
import axios from "axios";
import { Link } from "react-router-dom"



interface Specialization {
		id: number,
		name: string,
		link: string,
		icon: string,
	  }
interface Doctor {
		id: string,
		specialist: string,
		firstName: string,
		lastName: string
	  }

const CategoriesSearch = () => {
  const [doctors, setDoctors] = useState<Doctor[]>([]);
  const [selectedSpecialization, setSelectedSpecialization] =
    useState<Specialization | null>(null);

  const specializations: Array<Specialization> = [
		{
			id: 1,
		  	name: "dermatolog",
		  	link: "/",
		  	icon: dermatolog,
		},
		{
			id: 2,
		  	name: "gastrolog",
		  	link: "/",
		  	icon: gastrolog,
		},
		{
			id: 3,
		  	name: "ginekolog",
		  	link: "/",
		  	icon: ginekolog,
		},
		{
			id: 4,
		  	name: "hematolog",
		  	link: "/",
		  	icon: hematolog,
		},
		{
			id: 5,
		  	name: "hepatolog",
		  	link: "/",
		  	icon: hepatolog,
		},
		{
			id: 6,
		  	name: "kardiolog",
		  	link: "/",
		  	icon: kardiolog,
		},
		{
			id: 7,
		  	name: "laryngolog",
		  	link: "/",
		  	icon: laryngolog,
		},
		{
			id: 8,
		  	name: "neurolog",
		  	link: "/",
		  	icon: neurolog,
		},
		{
			id: 9,
		  	name: "ogolny",
		  	link: "/",
		  	icon: ogolny,
		},
		{
			id: 10,
		  	name: "okulista",
		  	link: "/",
		  	icon: okulista,
		},
		{
			id: 11,
		  	name: "ortopeda",
		  	link: "/",
		  	icon: ortopeda,
		},
		{
			id: 12,
		  	name: "pediatra",
		  	link: "/",
		  	icon: pediatra,
		},
		{
			id: 13,
		  	name: "plastyczny",
		  	link: "/",
		  	icon: plastyczny,
		},
	  ]
	
		

	  const getDoctorsBySpecialization = async (specialization: Specialization) => {
		try {
		  const response = await axios.get(
			`${api_path}/api/doctors/search/${specialization.name}`
		  );
		  setDoctors(response.data);
		} catch (error) {
		  console.error(error);
		}
	  };
	
	  const onSpecializationClick = async (specialization: Specialization) => {
		setSelectedSpecialization(specialization);
		await getDoctorsBySpecialization(specialization);
	  };
	
	  const specElements = specializations.map((specialization, i) => (
		<div
		  key={specialization.id}
		  id={specialization.name}
		  style={{ width: "150px" }}
		  onClick={() => onSpecializationClick(specialization)}
		>
		  <img
			src={specialization.icon}
			alt="placeholder"
			className={
			  selectedSpecialization?.name === specialization.name
				? "specjalizacja selected"
				: "specjalizacja"
			}
			style={{ width: "150px", height: "150px", padding: 8 }}
		  />
		</div>
	  ));


	  const doctorElements = doctors.map((doctor) => (
		<div key={doctor.id} className="doctor-card">
		  <Link to={`/doctor/profile/${doctor.id}`}>
		  <img
			src={doctorImage}
			alt="Doctor"
			style={{ width: "150px", height: "200px" }}
		  />
		  <table>
			<tbody>
			  <tr>
				<th>Specjalizacja:</th>
				<td>{doctor.specialist}</td>
			  </tr>
			  <tr>
				<th>Imię:</th>
				<td>{doctor.firstName}</td>
			  </tr>
			  <tr>
				<th>Nazwisko:</th>
				<td>{doctor.lastName}</td>
			  </tr>
			</tbody>
		  </table>
		  </Link>
		</div>
	  ));
	
	  return (
		<main>
		  <div className="p" style={{ marginLeft: 20 }}>
			<Searcher />
			<p className="text-specjalizacja">SPECJALIZACJA</p>
			<Carousel show={11} infiniteLoop={true}>
			  {specElements}
			</Carousel>
		  </div>
		  <div className="w" style={{ marginLeft: 25 , marginTop: 10}}>
			<p className="text-wyszukiwanie">WYSZUKIWANIE</p>
		  </div>
		  <div id="people-container" className="doctor-container">
			{doctorElements.length === 0 ? (
			  <p style={{ marginLeft: 500 , textAlign: 'center' }}>BRAK LEKARZY O PODANEJ SPECJALIZACJI</p>
			) : (
			  doctorElements
			)}
		  </div>
		</main>
	  );
			}	  
	
	export default CategoriesSearch;