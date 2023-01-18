import Search from "./Search";
import Categories from "./Categories";
import Specialization from "./Specialization";

function Searcher() {
	return (
		<div className="searcher">
			<Categories />
			<Search />
			<Specialization/>

		</div>
	);
}

export default Searcher;
