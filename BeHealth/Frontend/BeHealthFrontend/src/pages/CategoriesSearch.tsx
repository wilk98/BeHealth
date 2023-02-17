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
import './CategoriesSearch.css'
import { useState } from "react"




export const CategoriesSearch = () => {
	const [selected, setSelected] = useState(0)
	

	interface Specjalizacja {
		id: number,
		name: string,
		link: string,
		icon: string,
	  }
	


	  const specjalizacje: Array<Specjalizacja> = [
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
		const specialization = document.getElementsByClassName('selected').item(1)?.id;
		console.log(specialization)
		
		interface Doctor {
			id: string,
			specialist: string,
			name: string
		  }
	
		
	  const specElements = specjalizacje.map((specjalizacja, i) => (
		<div onClick={() => setSelected(i)} className={selected === i ? 'selected ' : ''}  id={specjalizacja.name} style={{width:"150px"}}>
			<img src={specjalizacja.icon}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
		</div>
	  ))
	  
	return (
		<main>
			<div className="p" style={{ marginLeft: 20 }}>
				<Searcher />
				<p className="text-specjalizacja">SPECJALIZACJA</p>
				<Carousel show={11} infiniteLoop={true}>
					{specElements}
				</Carousel>
			</div>
		</main>
	)

}