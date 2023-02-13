import Carousel from "../components/layout/Searcher/Carousel"
import Searcher from "../components/layout/Searcher/Searcher"
import picture from "../assets/images/specialization-rectangle.png"



function CategoriesSearch() {
	var actualWidth = document.querySelector('main')?.offsetWidth;
    if (actualWidth != null)
    {
        var itemOnPage = Math.floor(actualWidth/170);
        console.log(itemOnPage);
    }
    else
    {
        itemOnPage = 0;
    }
	return (
		<main >
			
			<div className="p" style={{ marginLeft: 20 }}>
			<Searcher />
				<Carousel show={itemOnPage}>
					<div className="picture" style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture" style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
					<div className="picture"style={{width:"150px"}}>
						<img src={picture}alt="placeholder" style={{ width: '150px', height: "150px", padding: 8}} />
					</div>
				</Carousel>
			</div>
		</main>
	)
}

export default CategoriesSearch