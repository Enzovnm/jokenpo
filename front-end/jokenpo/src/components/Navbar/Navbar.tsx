import btgLogo from "../../assets/btg-logo.png";
import { Link } from "react-router";

const Navbar = () => {
  return (
    <nav className="w-full bg-white h-20 flex items-center justify-between p-5">
      <div className="h-full flex items-center">
        <img
          src={btgLogo}
          alt="BTG Logo"
          className="h-10 w-auto object-contain"
        />
      </div>
      <ul className="flex gap-2">
        <Link to={"/"}>Game</Link>
        <Link to={"moves"}>Moves</Link>
      </ul>
    </nav>
  );
};

export default Navbar;
