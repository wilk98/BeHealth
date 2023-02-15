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




function CategoriesSearch() {

	return (
		<main>
			<div className="p" style={{ marginLeft: 20 }}>
				<Searcher />
				<p className="text-specjalizacja">SPECJALIZACJA</p>
				<Carousel show={11} infiniteLoop={true}>
					<div className="picture" style={{width:"150px", border: "grey"}}>
						<img src={dermatolog}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture" style={{width:"150px"}}>
						<img src={gastrolog}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={ginekolog}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={hematolog}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={hepatolog}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={kardiolog}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={laryngolog}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={neurolog}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={ogolny}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={okulista}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={ortopeda}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={pediatra}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={plastyczny}alt="placeholder" className="specjalizacja" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
				</Carousel>
			</div>
		</main>
	)
}

export default CategoriesSearch