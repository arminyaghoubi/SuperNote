import { useEffect, useState } from "react";
import { getNotes, getNoteDetails } from "../services/noteService";
import { Divider, FormControl, Grid, InputLabel, MenuItem, Pagination, Select, SelectChangeEvent } from "@mui/material";
import NoteList from "../components/NoteList/NoteList";
import NoteDetailsDialog from "../components/NoteDetailsDialog/NoteDetailsDialog";


const pageSizeList = [9, 12, 15]

function NoteListPage() {

    const [notes, setNotes] = useState([]);
    const [totalCount, setTotalCount] = useState(0);
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize, setPageSize] = useState(pageSizeList[0]);
    const [noteShowMore, setNoteShowMore] = useState(undefined);

    const handleChangePage = (_: React.ChangeEvent<unknown>, value: number) => {
        setCurrentPage(value);
        fetchNotes(value, pageSize);
    };

    const handleChangePageSize = (event: SelectChangeEvent<typeof pageSize>) => {
        const newPageSize = event.target.value as number;
        setPageSize(newPageSize);
        fetchNotes(currentPage, newPageSize);
    };

    const fetchNotes = async (pageNumber: number, pageSize: number) => {
        const response = await getNotes(pageNumber, pageSize);

        setNotes(response.notes);
        setTotalCount(response.totalCount);
    }

    const showMoreClicked = async (id: string) => {
        const response = await getNoteDetails(id);
        console.log(response);
        setNoteShowMore(response);
    }

    const closeNoteDetailsDialog = () => {
        setNoteShowMore(undefined);
    }

    useEffect(() => {
        fetchNotes(1, pageSize);
    }, []);

    return (
        <Grid container justifyContent="left" alignItems="center" spacing={2}>
            <Grid item xs={6} md={10}>
                <h3>Total Notes: {totalCount}</h3>
            </Grid>
            <Grid item xs={6} md={2}>
                <FormControl fullWidth>
                    <InputLabel id="demo-simple-select-label">Page Size</InputLabel>
                    <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={pageSize}
                        label="Age"
                        onChange={handleChangePageSize}
                    >
                        {pageSizeList.map((name) => (
                            <MenuItem
                                key={name}
                                value={name}
                            >
                                {name}
                            </MenuItem>
                        ))}
                    </Select>
                </FormControl>
            </Grid>
            <Grid item xs={12}>
                <Divider />
            </Grid>
            <Grid item xs={12}>
                <NoteList showMoreClicked={showMoreClicked} notes={notes} totalCount={totalCount} />

                <Pagination count={Math.ceil(totalCount / pageSize)}
                    page={currentPage}
                    onChange={handleChangePage}
                    variant="outlined"
                    shape="rounded"
                    color="primary" />
            </Grid>
            <NoteDetailsDialog note={noteShowMore} close={closeNoteDetailsDialog} />
        </Grid>
    );
}

export default NoteListPage;