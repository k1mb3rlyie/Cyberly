import spacy  # better than NLTK for me, easier to use
import re  # this is to remove unecesssary stuff
from transformers import pipeline

# thi sis fpr the summaries, i used the tranformers library

from sklearn.feature_extraction.text import CountVectorizer

# tfidf
from sklearn.feature_extraction.text import TfidfVectorizer
from sentence_transformers import SentenceTransformer

# for embeddings
import numpy as np

# Load spaCy model
nlp = spacy.load("en_core_web_sm")


with open("answers.txt", "r") as file:
    answers = file.readlines()  # fFILE

# removing punctuation first
cleaned_answers = [
    re.sub(r"[^\w\s]", "", answer.strip()) for answer in answers if answer.strip()
]

# Tokenize answers
tokenized_answers = [nlp(answer) for answer in cleaned_answers]

for i, answer in enumerate(tokenized_answers):
    print(f"Answer {i + 1}: {[token.text for token in answer]}")

# Write tokenized answers to a file
with open("tokenized_answers.txt", "w") as f:
    for answer in tokenized_answers:
        tokens = [token.text for token in answer]
        f.write(" ".join(tokens) + "\n")

print("Tokenized answers saved to tokenized_answers.txt")

##
##
# fir summaries

summarizer = pipeline("summarization", model="t5-small")
summaries = []


for i, answer in enumerate(cleaned_answers):
    if len(answer.split()) < 0:  # Skip very short answers for functionality
        print(f"Answer {i + 1} is too short for summarization: {answer}")
        summaries.append("Too short to summarize.")
        continue

    # Summarize the answer
    summary = summarizer(answer, max_length=100, min_length=100, do_sample=False)[0][
        "summary_text"
    ]
    summaries.append(summary)

    # Print summary for debugging
    print(f"Summary for Answer {i + 1}: {summary}")

# Save all summaries to a file
with open("summarized_answers.txt", "w") as file:
    for i, summary in enumerate(summaries):
        file.write(f"Summary {i + 1}: {summary}\n")

print("Summaries saved to file summarized_answers.txt")

##
##
####  feature extraction,
# the bag of words 'BoW' to turn my answers to vectors the NLP willl understand


def bag_of_words(corpus):
    vectorizer = CountVectorizer()
    x = vectorizer.fit_transform(corpus)
    return x.toarray(), vectorizer.get_feature_names_out()


with open("answers.txt", r) as file:
    text_corpus = file.readlines()


bow_features, bow_feature_names = bag_of_words(text_corpus)
print(bow_features)
print(bow_feature_names)

with open("BoW.txt", "w") as file:
    for i, bow in enumerate(bow_feature_names):
        file.write(f"{i + 1}: \n")  # save as a file


##
# for the term frequency inverse docucument frequency


def tfidf_vectorization(corpus):
    vectorizer = TfidfVectorizer()
    x = vectorizer.fit_transform(corpus)
    return x.toarray(), vectorizer.get_feature_names_out()


tfidf_features, tfidf_feature_names = tfidf_vectorization(text_corpus)
print(tfidf_features)
print(tfidf_feature_names)

with open("TFIDFreq.txt", "w") as file:
    for i, bow in enumerate(tfidf_eature_names):
        file.write(f"{i + 1}: \n")


#
## functon to return sentence ebeddings
def sentence_embeddings(sentences):
    model = SentenceTransformer("all-MiniLM-L6-v2")
    embeddings = model.encode(sentences)
    return embeddings


embeddings = sentence_embeddings(text_corpus)
print(embeddings)

np.savetxt("embeddings.txt", embeddings)
