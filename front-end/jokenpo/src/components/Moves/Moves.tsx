import React, { useEffect, useState } from "react";
import Select from "react-select";

interface Move {
  id: number;
  name: string;
}

interface Option {
  value: number;
  label: string;
}

export const Moves = () => {
  const [name, setName] = useState("");
  const [winnerIds, setWinnerIds] = useState<number[]>([]);
  const [moves, setMoves] = useState<Move[]>([]);

  useEffect(() => {
    const fetchMoves = async () => {
      const response = await fetch("http://localhost:5237/moves");
      const data = await response.json();
      setMoves(data);
    };

    fetchMoves();
  }, []);

  const options: Option[] = moves.map((move) => ({
    value: move.id,
    label: move.name,
  }));

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const createMoveResponse = await fetch("http://localhost:5237/moves", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ name }),
      });

      if (!createMoveResponse.ok) {
        throw new Error("Error when creating move");
      }

      const createdMove: Move = await createMoveResponse.json();

      await fetch(`http://localhost:5237/moves/${createdMove.id}/winners`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          winnerIds,
        }),
      });

      alert("Move created");

      setName("");
      setWinnerIds([]);

      window.location.reload();
    } catch (error) {
      console.error(error);
      alert("Error when creating move");
    }
  };

  return (
    <section className="bg-white w-11/12 lg:w-[50vw] m-auto h-[70vh] mt-20 p-5 shadow-2xl">
      <h1 className="font-bold uppercase text-center mt-4 text-3xl">
        BTG - Jokenpo
      </h1>

      <div className="h-10/12 flex justify-center items-center">
        <form
          onSubmit={handleSubmit}
          className="w-full max-w-md flex flex-col gap-4"
        >
          <div className="flex flex-col">
            <label className="font-semibold mb-1">Move Name</label>
            <input
              type="text"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className="border p-2 rounded"
              placeholder="Ex: Rock"
              required
            />
          </div>

          <div className="flex flex-col">
            <label className="font-semibold mb-1">Wins Against</label>

            <Select
              isMulti
              options={options}
              required={true}
              className="text-black"
              onChange={(selected) =>
                setWinnerIds(selected.map((o) => o.value))
              }
            />
          </div>

          <button
            type="submit"
            className="cursor-pointer self-center bg-green-500 w-full py-5 rounded-2xl font-bold text-white"
          >
            Create Move
          </button>
        </form>
      </div>
    </section>
  );
};
