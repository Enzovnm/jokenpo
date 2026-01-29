import React, { useEffect, useState } from "react";
import playerLogo from "../../assets/player.png";
import { Modal } from "./Modal";

interface Move {
  id: number;
  name: string;
}

interface Player {
  id: number;
  name: string;
}

const JokenpoHero = () => {
  const apiUrl = import.meta.env.VITE_API_URL;

  const [Moves, setMoves] = useState<Move[]>([]);

  const [player, setPlayer] = useState<Player[]>([]);
  const [player1Selected, setPlayer1Selected] = useState<string>("");
  const [player2Selected, setPlayer2Selected] = useState<string>("");
  const [playerOneMove, setPlayerOneMove] = useState<string>("");
  const [playerTwoMove, setPlayerTwoMove] = useState<string>("");
  const [error, setError] = useState<string>("");
  const [open, setOpen] = useState<boolean>(false);
  const [data, setData] = useState<string>("");

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

  const handlePlayerOneMove = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setPlayerOneMove(event.target.value);
  };

  const handlePlayerTwoMove = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setPlayerTwoMove(event.target.value);
  };

  const handleOnClick = async () => {
    try {
      const response = await fetch(`${apiUrl}/jokenpo`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          player1Id: player1Selected,
          player2Id: player2Selected,
          player1MovementId: playerOneMove,
          player2MovementId: playerTwoMove,
        }),
      });
      if (!response.ok) {
        const rawText = await response.text();
        let message = "Error, check the fields";

        try {
          const error = JSON.parse(rawText);
          message = error?.title ?? rawText;
        } catch {
          message = rawText;
        }

        setError(message);
        return;
      }

      setError("");

      const data = await response.json();

      setData(data.message);
      setOpen(true);
    } catch (err) {
      console.error("Erro ao criar match:", err);
    }
  };

  useEffect(() => {
    Promise.all([
      fetch(`${apiUrl}/moves`).then((r) => r.json()),
      fetch(`${apiUrl}/players`).then((r) => r.json()),
    ])
      .then(([movesData, playersData]) => {
        setMoves(movesData);
        setPlayer(playersData);
      })
      .catch(console.error);
  }, []);

  return (
    <main className="bg-white w-11/12 lg:w-[50vw] m-auto h-[70vh] mt-20 p-5 shadow-2xl">
      <h1 className="font-bold uppercase text-center mt-4 text-3xl">
        BTG - Jokenpo
      </h1>
      <div className="flex mt-4 lg:mt-0 lg:text-2xl  lg:items-center">
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
            <label className="text-sm text-center">Move:</label>
            <select
              value={playerOneMove}
              className="mt-2 lg:w-40 w-24 border border-gray-300 rounded px-2 py-1 text-sm"
              onChange={handlePlayerOneMove}
            >
              <option value="" disabled>
                Select Move
              </option>
              {Moves.map((move) => (
                <option key={move.id} value={move.id}>
                  {move.name}
                </option>
              ))}
            </select>
          </div>
        </div>
        <button
          className="cursor-pointer bg-green-500 w-20 text-white font-bold lg:w-72 h-full self-center py-5 rounded-2xl"
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
            <label className="text-sm text-center">Move:</label>
            <select
              value={playerTwoMove}
              onChange={handlePlayerTwoMove}
              className="mt-2 lg:w-40 w-24 border border-gray-300 rounded px-2 py-1 text-sm"
            >
              <option value="" disabled>
                Select move
              </option>
              {Moves.map((move) => (
                <option key={move.id} value={move.id}>
                  {move.name}
                </option>
              ))}
            </select>
          </div>
        </div>
      </div>
      {error && (
        <div className="w-full">
          <h2 className="text-xl w-full text-center text-red-500">{error}</h2>
        </div>
      )}
      <Modal isOpen={open} onClose={() => setOpen(false)}>
        <h2 className="text-center font-bold">{data}</h2>
      </Modal>
    </main>
  );
};

export default JokenpoHero;
