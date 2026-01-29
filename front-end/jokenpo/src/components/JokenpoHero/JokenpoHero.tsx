import React, { useEffect, useState } from "react";
import playerLogo from "../../assets/player.png";

interface Move {
  id: number;
  name: string;
}

interface Player {
  id: number;
  name: string;
}

const JokenpoHero = () => {
  const [movements, setMovements] = useState<Move[]>([]);

  const [player, setPlayer] = useState<Player[]>([]);
  const [player1Selected, setPlayer1Selected] = useState<string>("");
  const [player2Selected, setPlayer2Selected] = useState<string>("");
  const [playerOneMovement, setPlayerOneMovement] = useState<string>("");
  const [playerTwoMovement, setPlayerTwoMovement] = useState<string>("");

  const handlePlayer1Selected = (
    event: React.ChangeEvent<HTMLSelectElement>,
  ) => {
    setPlayer1Selected(event.target.value);
  };

  const handlePlayer2Selected = (
    event: React.ChangeEvent<HTMLSelectElement>,
  ) => {
    setPlayer2Selected(event.target.value);
  };

  const handlePlayerOneMovement = (
    event: React.ChangeEvent<HTMLSelectElement>,
  ) => {
    setPlayerOneMovement(event.target.value);
  };

  const handlePlayerTwoMovement = (
    event: React.ChangeEvent<HTMLSelectElement>,
  ) => {
    setPlayerTwoMovement(event.target.value);
  };

  const handleOnClick = async () => {
    try {
      const response = await fetch("http://localhost:5237/jokenpo", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          player1Id: player1Selected,
          player2Id: player2Selected,
          player1MovementId: playerOneMovement,
          player2MovementId: playerTwoMovement,
        }),
      });

      if (!response.ok) {
        const error = await response.text();
        throw new Error(error);
      }

      const data = await response.json();
      console.log("Resultado:", data);
    } catch (err) {
      console.error("Erro ao criar match:", err);
    }
  };

  useEffect(() => {
    Promise.all([
      fetch("http://localhost:5237/moves").then((r) => r.json()),
      fetch("http://localhost:5237/players").then((r) => r.json()),
    ])
      .then(([movesData, playersData]) => {
        setMovements(movesData);
        setPlayer(playersData);
      })
      .catch(console.error);
  }, []);

  return (
    <main className="bg-white w-11/12 lg:w-[50vw] m-auto h-[70vh] mt-20 p-5 shadow-2xl">
      <h1 className="font-bold uppercase text-center mt-4 text-3xl">
        BTG - Jokenpo
      </h1>
      <div className="flex h-full mt-4 lg:mt-0 lg:text-2xl  lg:items-center">
        <div className=" w-1/2 lg:h-128  flex-col flex items-center justify-center">
          <h2 className="text-center items">Player 1</h2>
          <div className="  w-24 lg:w-48">
            <img src={playerLogo} className="" alt="player1"></img>
          </div>

          <div className="flex flex-col">
            <label className="text-sm text-center">Player1:</label>

            <select
              value={player1Selected}
              className="mt-2 lg:w-40 w-24 border border-gray-300 rounded px-2 py-1 text-sm"
              onChange={handlePlayer1Selected}
            >
              <option value="" disabled>
                Select player1
              </option>
              {player.map((player) => (
                <option key={player.id} value={player.id}>
                  {player.name}
                </option>
              ))}
            </select>
            <label className="text-sm text-center">Movement:</label>
            <select
              value={playerOneMovement}
              className="mt-2 lg:w-40 w-24 border border-gray-300 rounded px-2 py-1 text-sm"
              onChange={handlePlayerOneMovement}
            >
              <option value="" disabled>
                Select Move
              </option>
              {movements.map((move) => (
                <option key={move.id} value={move.id}>
                  {move.name}
                </option>
              ))}
            </select>
          </div>
        </div>
        <button
          className="cursor-pointer bg-green-500 w-40 py-5 rounded-2xl"
          onClick={handleOnClick}
        >
          Play
        </button>
        <div className=" w-1/2 lg:h-128  flex-col flex items-center justify-center">
          <h2 className="text-center items">Player 2</h2>
          <div className="w-24 lg:w-48">
            <img src={playerLogo} className="" alt="player2"></img>
          </div>

          <div className="flex flex-col">
            <label className="text-sm text-center">Player2:</label>

            <select
              value={player2Selected}
              className="mt-2 lg:w-40 w-24 border border-gray-300 rounded px-2 py-1 text-sm"
              onChange={handlePlayer2Selected}
            >
              <option value="" disabled>
                Select player2
              </option>
              {player.map((player) => (
                <option key={player.id} value={player.id}>
                  {player.name}
                </option>
              ))}
            </select>
            <label className="text-sm text-center">Movement:</label>
            <select
              value={playerTwoMovement}
              onChange={handlePlayerTwoMovement}
              className="mt-2 lg:w-40 w-24 border border-gray-300 rounded px-2 py-1 text-sm"
            >
              <option value="" disabled>
                Select move
              </option>
              {movements.map((move) => (
                <option key={move.id} value={move.id}>
                  {move.name}
                </option>
              ))}
            </select>
          </div>
        </div>
      </div>
    </main>
  );
};

export default JokenpoHero;
